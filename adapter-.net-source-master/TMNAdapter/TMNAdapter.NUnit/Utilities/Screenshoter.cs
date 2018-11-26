﻿using TMNAdapter.Core.Tracking.Attributes;
using TMNAdapter.Core.Utilities;
using TMNAdapter.Tracking.Attributes;

namespace TMNAdapter.Utilities
{
    public class Screenshoter : BaseScreenshoter
    {
        private static Screenshoter screenshoter;

        public static Screenshoter Instance
        {
            get
            {
                return screenshoter = screenshoter ?? (screenshoter = new Screenshoter());
            }
        }

        public override void CloseScreenshoter()
        {
            driverInstance = null;
            screenshoter = null;
        }

        protected override string GetIssue()
        {
            return AnnotationTracker.GetAttributeInCallStack<JiraTestMethodAttribute>()?.Key;
        }
    }
}
