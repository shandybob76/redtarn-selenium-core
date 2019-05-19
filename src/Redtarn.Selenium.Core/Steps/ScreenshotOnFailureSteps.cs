// <copyright file="ScreenshotOnFailureSteps.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using TechTalk.SpecFlow;

namespace RedTarn.Selenium.Core.Steps
{
    /// <summary>
    /// Steps to take a screenshot of the error state of the browser on
    /// failure.
    /// </summary>
    [Binding]
    public class ScreenshotOnFailureSteps : BaseSteps
    {
        /// <summary>
        /// The scenario context.
        /// </summary>
        private readonly ScenarioContext scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenshotOnFailureSteps"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="scenarioContext">The scenario context.</param>
        public ScreenshotOnFailureSteps(IContext context, ScenarioContext scenarioContext)
            : base(context)
        {
            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Process the test failure screenshot if needed.
        /// </summary>
        [AfterScenario(Order = int.MinValue)]
        public void ProcessTestFailureScreenshot()
        {
            if (this.scenarioContext.TestError != null)
            {
                this.Context.UI.TakeScreenshot(this.scenarioContext);
            }
        }
    }
}
