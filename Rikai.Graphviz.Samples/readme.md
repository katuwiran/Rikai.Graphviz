## Samples

Please inspect the files themselves; some lines are documented, some require a bit of C# knowledge. The outputs of these files are on the assets folder, some are even on the main page's readme.

Here, I will explain some of the wizardry on the `Meta.cs` file.

I personally prefer using Fluent API as it is less verbose than chained initializations.

The primary motivation for this repo is to easily reuse predefined attributes across different instances on your graph. Think of flow charts with predefined symbols where the only differences on nodes are the labels and shapes.

On `Meta.cs`, the predefined attributes are written as an anonymous tuple, e.g.

```csharp
// node attributes
var nodes = ( // a tuple of attributes 
  Normal: new NodeAttributeBuilder() // Build() returns NodeAttributes
    .Shape(Shape.Rectangle)
    .Color(colors.Text)
    .FontColor(colors.Text)
    .Build(),
  Finished: new NodeAttributeBuilder()
    .Shape(Shape.Rectangle)
    .Color(colors.Green)
    .FontColor(colors.Green)
    .Build(),
  Ongoing: new NodeAttributeBuilder()
    .Shape(Shape.Rectangle)
    .Color(colors.Plum)
    .FontColor(colors.Plum)
    .Build()
;
```

and using that is as simple as doing something like

```csharp
var graph = new GraphBuilder()
  .AddNode("I'm Finished!",      nodes.Finished)   
  .AddNode("I'm still ongoing!", nodes.ongoing)
  .Build()
```

I used anonymous tuples because I like its syntax better than anonymous types, but its elements are limited. Converting to anonymous types will be quick, however, so it is not that much of a concern.