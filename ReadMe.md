# V9 Starter Site

This is just a play site I have created for me to learn the new Block List editor and to test Blazor works as expected in V9 without any major problems.

Hopefully some of this site is useful for someone looking to start out with v9 and .Net 5. Some of the concepts this repo has in it which might be of interest to someone new to umbraco v9 :/

- Uses a root node (Website) for settings with the home page set via umbracoInternalRedirectID
- Blazor for the header and the mobile navigation overlay (No JS)
- Blazor and FluentValidation for the Contact Form Block
- Example of using Blazor code behinds for components (+ Dependency injection and parameters)
- View Components to render the Block Lists
- Nested Block Lists and again renders with View Components
- Models Builder for all models (Including custom partial classes to pass the root id around)
- Tailwind Css ([Main styles taken from the awesome Tailwind UI](https://tailwindui.com/))
- Fully working example of using Block List Editor, front and back end rendering, settings etc...

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
- Statistics Block
- Article/Free Text Block
- Content Boxes Block
- Contact Form block

### Install Package

TODO

### Video

https://www.youtube.com/watch?v=JoYZtwylTxw

### Front End Screenshot

![](https://www.aptitude.co.uk/v9umb.png?)

### Back End Screenshot

Custom views for block list editor used to get very similar editor experience.

![](https://www.aptitude.co.uk/v9umb-be.png)