# How to improve your code knowing how the Garbage Collector works in C# 

Documentation can be found here: https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals

This repository has 2 projects, one Main project with some examples and benchmarks, the second one is for common stuff. 


## Diagrams

<b>Garbage Collector working</b>

![](https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/media/fundamentals/background-server-garbage-collection.png)
  

## Rules to follow to write better code

- Avoid using boxing and unboxing
- Do not concatenate strings
- Use structs instead of classes when you need to manipulate lots of copies of the an object and don't need a constructor
- Always pre-sizsze collections (resizing is cost)
- Avoid calling ToList() in LINQ expressions
