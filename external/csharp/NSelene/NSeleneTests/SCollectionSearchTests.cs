﻿using NUnit.Framework;
using NSelene;
using OpenQA.Selenium;

namespace NSeleneTests
{
    [TestFixture]
    public class SCollectionSearchTests : BaseTest
    {

        [TearDown]
        public void TeardownTest()
        {
            Configuration.Timeout = 4;
        }
        
        [Test]
        public void SCollectionSearchIsLazyAndDoesNotStartOnCreation()
        {
            var nonExistingCollection = Selene.SS(".not-existing");
            Assert.IsNotEmpty(nonExistingCollection.ToString()); 
                // TODO: think on improving... actually it does not tell search is not started
                // it would tell if browser is quited at the moment... but it is not...
        }

        [Test]
        public void SCollectionSearchIsPostponedUntilActualActionLikeQuestioiningCount()
        {
            Given.OpenedEmptyPage();
            var elements = Selene.SS(".will-appear");
            When.WithBody(@"
                <ul>Hello to:
                    <li class='will-appear'>Bob</li>
                    <li class='will-appear'>Kate</li>
                </ul>");
            Assert.AreEqual(2, elements.Count);
        }

        [Test]
        public void SCollectionSearchIsUpdatedOnNextActualActionLikeQuestioiningCount()
        {
            Given.OpenedEmptyPage();
            var elements = Selene.SS(".will-appear");
            When.WithBody(@"
                <ul>Hello to:
                    <li class='will-appear'>Bob</li>
                    <li class='will-appear'>Kate</li>
                </ul>");
            Assert.AreEqual(2, elements.Count);
            When.WithBody(@"
                <ul>Hello to:
                    <li class='will-appear'>Bob</li>
                    <li class='will-appear'>Kate</li>
                    <li class='will-appear'>Joe</li>
                </ul>");
            Assert.AreEqual(3, elements.Count);
        }

        [Test]
        public void SCollectionSearchWaitsNothing()
        {
            Given.OpenedEmptyPage();
            var elements = Selene.SS(".will-appear");
            When.WithBody(@"
                <ul>Hello to:
                    <li class='will-appear'>Bob</li>
                    <li class='will-appear' style='display:none'>Kate</li>
                </ul>"
            );
            When.WithBodyTimedOut(@"
                <ul>Hello to:
                    <li class='will-appear'>Bob</li>
                    <li class='will-appear' style='display:none'>Kate</li>
                    <li class='will-appear'>Bobik</li>
                </ul>",
                500
            );
            Assert.AreEqual(2, elements.Count);
        }
    }
}

