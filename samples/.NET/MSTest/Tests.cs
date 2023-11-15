using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlaywrightTests;

[TestClass]
public class Tests : PageTest

{
    [TestMethod]

    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
        
       var context = await Browser.NewContextAsync();

        // // Start tracing.
        // await context.Tracing.StartAsync(new()
        // {
        //     Screenshots = true,
        //     Snapshots = true,
        //     Sources = true
        // });
        
        var page = await context.NewPageAsync();
        await page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(page).ToHaveURLAsync(new Regex(".*intro"));
        
        // // Stop tracing and export it into a zip archive.
        // await context.Tracing.StopAsync(new()
        // {
        //      Path = "<Add absolute path>" + "trace.zip"
        // });
    }
}