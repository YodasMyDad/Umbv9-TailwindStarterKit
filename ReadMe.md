# V9 Starter Site

**!!Read Me - Work in progress!! Front end is 80% done, and then I want to add views and CSS for the backend so the block list matches the front end. However, this is all working but just not finished**

This is just a play site I have created for me to learn the new Block List editor and to test Blazor works as expected in V9 without any major problems.

Hopefully some of this site is useful for someone looking to start out with v9 and .Net 5. Some of the things this repo has in it which might be of interest to someone new to umbraco v9 :/

- Uses a root node (Website) for settings with the home page set via umbracoInternalRedirectID
- Uses Blazor for the header and the mobile navigation overlay (No JS)
- Uses View Components to render the Block Lists
- Uses Nested Block Lists and again renders with View Components
- Uses Models Builder for all models
- Uses Tailwind Css ([Main styles taken from the awesome Tailwind UI](https://tailwindui.com/))

### Getting Started

Just clone the site, restore the nuget packages, build and run. The admin login details are:

admin@admin.co.uk  
1234567890

### Tailwind Css

The site has Tailwind JIT setup, so run the NPM script 'watch-css' and it will auto rebuild and add/remove tailwind classes as you save your views.

### Current Blocks

The current blocks that come with it are shown below, they are (in order)

- Hero Block
- Feature Block
- Call To Action Block
- Question & Answer Block
- Article/Free Text Block

I have plans for a couple of other blocks, which I'll add at the end.

![](https://www.aptitude.co.uk/v9umb.png)
