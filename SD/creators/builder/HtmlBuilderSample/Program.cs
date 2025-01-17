﻿using System.Text;
using HtmlBuilderSample;
using static System.Console;

{
   // if you want to build a simple HTML paragraph using StringBuilder
   var hello = "hello";
   var sb = new StringBuilder();
   sb.Append("<p>");
   sb.Append(hello);
   sb.Append("</p>");
   WriteLine(sb);

   // now I want an HTML list with 2 words in it
   var words = new[] { "hello", "world" };
   sb.Clear();
   sb.Append("<ul>");
   foreach (var word in words)
   {
      sb.AppendFormat("<li>{0}</li>", word);
   }

   sb.Append("</ul>");
   WriteLine(sb);

   // ordinary non-fluent builder
   var builder = new HtmlBuilder("ul");
   builder.AddChild("li", "hello");
   builder.AddChild("li", "world");
   WriteLine(builder.ToString());

   // fluent builder
   sb.Clear();
   builder.Clear(); // disengage builder from the object it's building, then...
   builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
   WriteLine(builder);
}

// with factory method
{
   var builder = HtmlElement.Create("ul");
   builder.AddChildFluent("li", "hello")
      .AddChildFluent("li", "world");
   WriteLine(builder);
}

// with implicit operator
{
   var root = HtmlElement
      .Create("ul")
      .AddChildFluent("li", "hello")
      .AddChildFluent("li", "world");
   WriteLine(root);
}