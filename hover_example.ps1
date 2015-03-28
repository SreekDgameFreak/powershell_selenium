# http://www.codeproject.com/Articles/856325/Mouse-Hover-Action-using-selenium-WebDriver

#Copyright (c) 2014 Serguei Kouzmine
#
#Permission is hereby granted, free of charge, to any person obtaining a copy
#of this software and associated documentation files (the "Software"), to deal
#in the Software without restriction, including without limitation the rights
#to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
#copies of the Software, and to permit persons to whom the Software is
#furnished to do so, subject to the following conditions:
#
#The above copyright notice and this permission notice shall be included in
#all copies or substantial portions of the Software.
#
#THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
#IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
#FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
#AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
#LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
#OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
#THE SOFTWARE.

param(
  [string]$hub_host = '127.0.0.1',
  [string]$browser ,
  [switch]$grid,
  [switch]$pause
)

function set_timeouts {
  param(
    [System.Management.Automation.PSReference]$selenium_ref,
    [int]$explicit = 120,
    [int]$page_load = 600,
    [int]$script = 3000
  )

  [void]($selenium_ref.Value.Manage().Timeouts().ImplicitlyWait([System.TimeSpan]::FromSeconds($explicit)))
  [void]($selenium_ref.Value.Manage().Timeouts().SetPageLoadTimeout([System.TimeSpan]::FromSeconds($pageload)))
  [void]($selenium_ref.Value.Manage().Timeouts().SetScriptTimeout([System.TimeSpan]::FromSeconds($script)))

}


# http://stackoverflow.com/questions/8343767/how-to-get-the-current-directory-of-the-cmdlet-being-executed
function Get-ScriptDirectory
{
  $Invocation = (Get-Variable MyInvocation -Scope 1).Value
  if ($Invocation.PSScriptRoot) {
    $Invocation.PSScriptRoot
  }
  elseif ($Invocation.MyCommand.Path) {
    Split-Path $Invocation.MyCommand.Path
  } else {
    $Invocation.InvocationName.Substring(0,$Invocation.InvocationName.LastIndexOf(""))
  }
}

function cleanup
{
  param(
    [System.Management.Automation.PSReference]$selenium_ref
  )
  try {
    $selenium_ref.Value.Quit()
  } catch [exception]{
    # Ignore errors if unable to close the browser
    Write-Output (($_.Exception.Message) -split "`n")[0]

  }
}


$shared_assemblies = @{
  'WebDriver.dll' = 2.44;
  'WebDriver.Support.dll' = '2.44';
  'nunit.core.dll' = $null;
  'nunit.framework.dll' = $null;

}


$shared_assemblies_path = 'c:\developer\sergueik\csharp\SharedAssemblies'

if (($env:SHARED_ASSEMBLIES_PATH -ne $null) -and ($env:SHARED_ASSEMBLIES_PATH -ne '')) {
  $shared_assemblies_path = $env:SHARED_ASSEMBLIES_PATH
}

pushd $shared_assemblies_path
$shared_assemblies.Keys | ForEach-Object {
  # http://all-things-pure.blogspot.com/2009/09/assembly-version-file-version-product.html
  $assembly = $_
  $assembly_path = [System.IO.Path]::Combine($shared_assemblies_path,$assembly)
  $assembly_version = [Reflection.AssemblyName]::GetAssemblyName($assembly_path).Version
  $assembly_version_string = ('{0}.{1}' -f $assembly_version.Major,$assembly_version.Minor)
  if ($shared_assemblies[$assembly] -ne $null) {
    # http://stackoverflow.com/questions/26999510/selenium-webdriver-2-44-firefox-33
    if (-not ($shared_assemblies[$assembly] -match $assembly_version_string)) {
      Write-Output ('Need {0} {1}, got {2}' -f $assembly,$shared_assemblies[$assembly],$assembly_path)
      Write-Output $assembly_version
      throw ('invalid version :{0}' -f $assembly)
    }
  }

  if ($host.Version.Major -gt 2) {
    Unblock-File -Path $_;
  }
  Write-Debug $_
  Add-Type -Path $_
}
popd


$verificationErrors = New-Object System.Text.StringBuilder

# use Default Web Site to host the page. Enable Directory Browsing.

$hub_port = '4444'
$uri = [System.Uri](('http://{0}:{1}/wd/hub' -f $hub_host,$hub_port))


try {
  $connection = (New-Object Net.Sockets.TcpClient)
  $connection.Connect($hub_host,[int]$hub_port)
  $connection.Close()
} catch {

if ($PSBoundParameters['grid']) {

    Start-Process -FilePath "C:\Windows\System32\cmd.exe" -ArgumentList "start cmd.exe /c c:\java\selenium\hub.cmd"
    Start-Process -FilePath "C:\Windows\System32\cmd.exe" -ArgumentList "start cmd.exe /c c:\java\selenium\node.cmd"

} else {
   Start-Process -FilePath "C:\Windows\System32\cmd.exe" -ArgumentList "start cmd.exe /c c:\java\selenium\selenium.cmd"
}
  Start-Sleep -Seconds 3


}


  Write-Debug "Running on ${browser}"
  if ($browser -match 'firefox') {
    $capability = [OpenQA.Selenium.Remote.DesiredCapabilities]::Firefox()

  }
  elseif ($browser -match 'chrome') {
    $capability = [OpenQA.Selenium.Remote.DesiredCapabilities]::Chrome()
  }
  elseif ($browser -match 'ie') {
    $capability = [OpenQA.Selenium.Remote.DesiredCapabilities]::InternetExplorer()
    if ($version -ne $null -and $version -ne 0) {
      $capability.SetCapability("version",$version.ToString());
    }

  }
  elseif ($browser -match 'safari') {
    $capability = [OpenQA.Selenium.Remote.DesiredCapabilities]::Safari()
  }
  else {
    throw "unknown browser choice:${browser}"
  }
  $selenium = New-Object OpenQA.Selenium.Remote.RemoteWebDriver ($uri,$capability)


$DebugPreference = 'Continue'
$base_url = 'http://www.myntra.com/'

$selenium.Navigate().GoToUrl($base_url)
$selenium.Manage().Window.Maximize()
set_timeouts ([ref]$selenium)

[NUnit.Framework.StringAssert]::Contains('www.myntra.com',$selenium.url,{})

[OpenQA.Selenium.Support.UI.WebDriverWait]$wait = New-Object OpenQA.Selenium.Support.UI.WebDriverWait ($selenium,[System.TimeSpan]::FromSeconds(1))
$wait.PollingInterval = 100


$xpath = "//a[@href='/shop/women?src=tn&nav_id=34']"
try {
  [void]$wait.Until([OpenQA.Selenium.Support.UI.ExpectedConditions]::ElementExists([OpenQA.Selenium.By]::XPath($xpath)))
} catch [exception]{
  Write-Output ("Exception with {0}: {1} ...`n(ignored)" -f $id1,(($_.Exception.Message) -split "`n")[0])
}
[OpenQA.Selenium.IWebElement]$element = $selenium.FindElement([OpenQA.Selenium.By]::XPath($xpath))
$text_url = $element.getAttribute('href')
Write-Output ('Hovering on : "{0}"' -f $text_url  )
[OpenQA.Selenium.Interactions.Actions]$actions = New-Object OpenQA.Selenium.Interactions.Actions ($selenium)
$actions.MoveToElement($element).Build().Perform()
Start-Sleep -Millisecond 1000

$xpath = "//a[@href='/shop/men?src=tn&nav_id=5']"
try {
  [void]$wait.Until([OpenQA.Selenium.Support.UI.ExpectedConditions]::ElementExists([OpenQA.Selenium.By]::XPath($xpath)))
} catch [exception]{
  Write-Output ("Exception with {0}: {1} ...`n(ignored)" -f $id1,(($_.Exception.Message) -split "`n")[0])
}
[OpenQA.Selenium.IWebElement]$element = $selenium.FindElement([OpenQA.Selenium.By]::XPath($xpath))
$text_url = $element.getAttribute('href')
Write-Output ('Hovering on : "{0}"' -f $text_url  )
[OpenQA.Selenium.Interactions.Actions]$actions = New-Object OpenQA.Selenium.Interactions.Actions ($selenium)
$actions.MoveToElement($element).Build().Perform()

if ($PSBoundParameters['pause']) {
  Write-Output 'pause'
  try {
    [void]$host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown')
  } catch [exception]{}
} else {
  Start-Sleep -Millisecond 1000
}


Start-Sleep -Millisecond 1000
# Click on " bags & backpacks " link
$xpath = "#a[@href='/men-bags-backpacks?src=tn&nav_id=25']"
Write-Output ('Locating via XPATH: "{0}"' -f $xpath)

[OpenQA.Selenium.Support.UI.WebDriverWait]$wait = New-Object OpenQA.Selenium.Support.UI.WebDriverWait ($selenium,[System.TimeSpan]::FromSeconds(1))
$wait.PollingInterval = 100
try {
  [void]$wait.Until([OpenQA.Selenium.Support.UI.ExpectedConditions]::ElementExists([OpenQA.Selenium.By]::XPath($xpath)))
} catch [exception]{
  Write-Output ("Exception with {0}: {1} ...`n(ignored)" -f $id1,$_.Exception.Message)
}

[OpenQA.Selenium.IWebElement]$element = $selenium.FindElement([OpenQA.Selenium.By]::XPath($xpath))

# [NUnit.Framework.Assert]::AreEqual('Caribbean',$element.Text)
[OpenQA.Selenium.Interactions.Actions]$actions = New-Object OpenQA.Selenium.Interactions.Actions ($selenium)
$actions.MoveToElement($element).Click().Build().Perform()


# click on the categories - Bagpacks

$xpath = "//*[text()='Categories']//following::li[1]/label']"
Write-Output ('Locating via XPATH: "{0}"' -f $xpath)

[OpenQA.Selenium.Support.UI.WebDriverWait]$wait = New-Object OpenQA.Selenium.Support.UI.WebDriverWait ($selenium,[System.TimeSpan]::FromSeconds(1))
$wait.PollingInterval = 100
try {
  [void]$wait.Until([OpenQA.Selenium.Support.UI.ExpectedConditions]::ElementExists([OpenQA.Selenium.By]::XPath($xpath)))
} catch [exception]{
  Write-Output ("Exception with {0}: {1} ...`n(ignored)" -f $id1,$_.Exception.Message)
}

[OpenQA.Selenium.IWebElement]$element = $selenium.FindElement([OpenQA.Selenium.By]::XPath($xpath))

# [NUnit.Framework.Assert]::AreEqual('Caribbean',$element.Text)
[OpenQA.Selenium.Interactions.Actions]$actions = New-Object OpenQA.Selenium.Interactions.Actions ($selenium)
$actions.MoveToElement($element).Click().Build().Perform()

# Hover on the 1st bag 
$xpath = "//ul[@class='results small']/li[1]"
Write-Output ('Locating via XPATH: "{0}"' -f $xpath)

[OpenQA.Selenium.Support.UI.WebDriverWait]$wait = New-Object OpenQA.Selenium.Support.UI.WebDriverWait ($selenium,[System.TimeSpan]::FromSeconds(1))
$wait.PollingInterval = 100
try {
  [void]$wait.Until([OpenQA.Selenium.Support.UI.ExpectedConditions]::ElementExists([OpenQA.Selenium.By]::XPath($xpath)))
} catch [exception]{
  Write-Output ("Exception with {0}: {1} ...`n(ignored)" -f $id1,$_.Exception.Message)
}

[OpenQA.Selenium.IWebElement]$element = $selenium.FindElement([OpenQA.Selenium.By]::XPath($xpath))

# [NUnit.Framework.Assert]::AreEqual('Caribbean',$element.Text)
[OpenQA.Selenium.Interactions.Actions]$actions = New-Object OpenQA.Selenium.Interactions.Actions ($selenium)
$actions.MoveToElement($element).Build().Perform()


#Click on the buy icon of the 1st bag
$xpath = "//ul[@class='results small']/li[1]/div[1]//div[2]"
Write-Output ('Locating via XPATH: "{0}"' -f $xpath)

[OpenQA.Selenium.Support.UI.WebDriverWait]$wait = New-Object OpenQA.Selenium.Support.UI.WebDriverWait ($selenium,[System.TimeSpan]::FromSeconds(1))
$wait.PollingInterval = 100
try {
  [void]$wait.Until([OpenQA.Selenium.Support.UI.ExpectedConditions]::ElementExists([OpenQA.Selenium.By]::XPath($xpath)))
} catch [exception]{
  Write-Output ("Exception with {0}: {1} ...`n(ignored)" -f $id1,$_.Exception.Message)
}

[OpenQA.Selenium.IWebElement]$element = $selenium.FindElement([OpenQA.Selenium.By]::XPath($xpath))

# [NUnit.Framework.Assert]::AreEqual('Caribbean',$element.Text)
[OpenQA.Selenium.Interactions.Actions]$actions = New-Object OpenQA.Selenium.Interactions.Actions ($selenium)
$actions.MoveToElement($element).Click().Build().Perform()

# Wait For Page To Load
# something better !!!
#  driver.manage().timeouts().implicitlyWait(60, TimeUnit.SECONDS);
<#  
# Hover over the shopping bag icon present on the top navigatinal bar   
Actions a3 = new Actions(driver);
a3.moveToElement(driver.findElement(By.xpath("#a[@href='/checkout/cart']"))).build().perform();
  
# click on the remove icon
driver.findElement(By.xpath("#a[@data-hint='Remove item']")).click();
#>

# Cleanup
cleanup ([ref]$selenium)



