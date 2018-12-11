﻿using System.Linq;

namespace NSelene
{
    namespace Conditions
    {
        public class CssClass : DescribedCondition<SeleneElement>
        {

            private string expected;
            private string actual;

            public CssClass(string expected)
            {
                this.expected = expected;
            }

            public override bool Apply(SeleneElement entity)
            {
                this.actual = entity.ActualWebElement.GetAttribute("class");

                // TODO: do we need this comparison with null? (we needed it in Java)
                return this.actual != null && this.actual.Split(' ').Contains(this.expected); 
            }

            public override string DescribeActual()
            {
                return this.actual;
            }

            public override string DescribeExpected()
            {
                return "has '" + this.expected + "'";
            }
        }

    }

    public static partial class Have
    {
        public static Conditions.Condition<SeleneElement> CssClass(string cssClass)
        {
            return new Conditions.CssClass(cssClass);
        }
    }

}
