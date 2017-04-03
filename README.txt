Solution Design
--

We make use of a couple of patterns here.

The first, and most obvious, is the factory pattern, which is used to create the set of classes derived from Drink and DrinkIngredient.
Secondly, we use the strategy pattern for validation of the drink's ingredients, although it is probably overkill for this particular scenario.

In addition to the above patterns, there are several "patterns" that some may not consider to be patterns, as they have been in common use
for longer than the term "pattern" has been used.

The "registry" pattern is used to lookup the concrete implementation of the drinks and ingredients.

There may be a few other patterns hiduing in there that I did not detect, and there is definitely more that could be done if one 
were willing to spend an unlimited amount of time.

I've kept the original interface, as sometimes you can't get rid of things immediately, due to other things depending on it.
I'm pretending that there might be other clients using this code, and given the incompleteness, there probably would be.
These clients would need to be upgraded to use the new interface. It should be noted that the original interface is more limited 
than the new one, which allows for additional products to be added relatively straightforwardly, with a view to eventually 
adopting a plugin architecture, whereby additional assemblies could be automatically loaded, and their types added to the cafe interface
automatically.

That is the direction I was looking in while refactoring the code.

You'll also notice that once the refactoring was done, making the changes required was relatively trivial, which shows what an impact
the design can have on extensibility and maintenance of code. No doubt that I could still improve it further, but I've left it better
than it was.

----
Several sites I have found useful in learning about such things

https://martinfowler.com/
and a link to the actual list of patterns - https://martinfowler.com/eaaCatalog/index.html

http://wiki.c2.com/ is particularly useful, but very easy to get lost down a rabbit hole reading the contributions
There is a pattern index here - http://wiki.c2.com/?PatternIndex - which starts from the GoF and extends onwards

On the contreversial side there are the following pages, which make for some interesting reading at least
http://wiki.c2.com/?DesignPatternsAreMissingLanguageFeatures
http://wiki.c2.com/?AreDesignPatternsMissingLanguageFeatures - this one is slightly better with some extra sources

