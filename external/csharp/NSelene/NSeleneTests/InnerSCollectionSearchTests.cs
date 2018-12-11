﻿using NUnit.Framework;
using NSelene;
// using static NSelene.Selene;
using OpenQA.Selenium;
using System.Threading;
using NSelene.Support.Extensions;

namespace NSeleneTests
{
    [TestFixture]
    public class InnerSCollectionSearchTests : BaseTest
    {

        [TearDown]
        public void TeardownTest()
        {
            Configuration.Timeout = 4;
        }
        
        [Test]
        public void InnerSCollectionSearchIsLazyAndDoesNotStartOnCreation()
        {
            Given.OpenedPageWithBody("<p id='#existing'>Hello!</p>");
            var nonExistingCollection = Selene.S("#existing").SS(".also-not-existing");
            Assert.IsNotEmpty(nonExistingCollection.ToString());  
            var nonExistingCollection2 = Selene.S("#not-existing").SS(".also-not-existing"); 
            Assert.IsNotEmpty(nonExistingCollection2.ToString()); 
        }

        [Test]
        public void InnerSCollectionSearchIsPostponedUntilActualActionLikeQuestioiningCount()
        {
            Given.OpenedEmptyPage();
            var elements = Selene.S("div").SS("li");
            When.WithBody(@"
                <div>
                    <ul>Hello to:
                        <li class='will-appear'>Bob</li>
                        <li class='will-appear'>Kate</li>
                    </ul>
                </div>"
            ); //TODO: consider simplifying example via removing div and using ul instead
            Assert.AreEqual(2, elements.Count);
        }

        [Test]
        public void InnerSCollectionSearchIsUpdatedOnNextActualActionLikeQuestioiningCount()
        {
            Given.OpenedEmptyPage();
            var elements = Selene.S("div").SS(".will-appear");
            When.WithBody(@"
                <div>
                    <ul>Hello to:
                        <li class='will-appear'>Bob</li>
                        <li class='will-appear'>Kate</li>
                    </ul>
                </div>"
            );
            Assert.AreEqual(2, elements.Count);
            When.WithBody(@"
                <div>
                    <ul>Hello to:
                        <li class='will-appear'>Bob</li>
                        <li class='will-appear'>Kate</li>
                        <li class='will-appear'>Joe</li>
                    </ul>
                </div>"
            );
            Assert.AreEqual(3, elements.Count);
        }

        [Test]
        public void InnerSCollectionSearchWaitsNothing()
        {
            Given.OpenedEmptyPage();
            var elements = Selene.S("div").SS(".will-appear");
            When.WithBody(@"
                <div>
                    <ul>Hello to:
                        <li class='will-appear'>Bob</li>
                        <li class='will-appear' style='display:none'>Kate</li>
                    </ul>
                </div>"
            );
            When.WithBodyTimedOut(@"
                <div>
                    <ul>Hello to:
                        <li class='will-appear'>Bob</li>
                        <li class='will-appear' style='display:none'>Kate</li>
                        <li class='will-appear'>Bobik</li>
                    </ul>
                </div>",
                500
            );
            Assert.AreEqual(2, elements.Count);
        }
    }
}

