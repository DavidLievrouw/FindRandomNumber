# Test

Write a program that *automatically* attempts to find an integer number between 0 and 10000. So there is no user input, the program should perform guesses by itself.

1) When the program starts, it generates a random number.
2) Write code that attempts to guess the random number.

Make sure that there are no more than 15 guesses, before the generated random number is found by the program.

Tip: You will probably need a method that evaluates a guess and returns the following values:
- 1 if the proposed number is greater than the number to guess.
- 0 if the proposed number is equal to the number to guess.
- -1 if the proposed number is smaller than the number to guess.

Write the output to the console, as follows (the numbers are only an example):
```
Proposing number “513”... incorrect.
Proposing number “8584”... incorrect.
Proposing number “243”... incorrect.
Proposing number “1023”... correct.
Guessed the number “1023” after 4 attempts.
```

### Remarks
- Pay special attention to the readability of your code, as well as the extendibility/flexibility.
- Not finished? No problem. The main focus of this assignment is to get an idea of your method of problem solving, and of your code style. Make sure that what you are coding, is something you are proud of.
- Make sure that the performance of your solution is acceptable. 
- Use OO principles. 
- Optional: Initialise a local git repository and indicate your progress by using small commits. 
- Optional: Use TDD.

### Timing
- Expected duration: 45 min.
- We’ll check every 15 minutes, to see how things are going.

### Additional questions
- How did you begin to solve this problem? What were your first steps? 
- Do your classes follow the Single Responsibility Principle? 
- What would you change if the number range changed from 0 to 10000 to -1 000 000 to +1 000 000? 
- If you had unlimited time, how would you improve your solution? 
- Can you draw a model of the ideal solution, in your opinion? 
- Could you identify reusable parts, and find good names for them? 
- Use Dependency Injection / Inversion of Control? 
- How would you go about making this project ultra-performant?

### Notes about the code
- This is an example solution. As with everything in the software development world, many of the choices are debatable.
- This solution was created during several hours of refactoring and debating amongst colleagues. It gives you a rough idea of our coding style. Giving only 45 minutes, gives us a decent idea of how you make difficult choices under time pressure.
- This solution is over-engineered, without a doubt. But again, it only serves as an example of our coding style.

### Change log
v1.0.0 - 2016-07-04
- Initial release.
