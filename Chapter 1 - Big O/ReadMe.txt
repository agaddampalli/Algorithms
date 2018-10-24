 
Gayle Laakmann McDowell:

In 2009, a South African company named The Unlimited grew frustrated by their ISP’s slow internet and made news by comically showing just how bad it is. They “raced” a carrier pigeon against their ISP. The pigeon had a USB stick affixed to its leg and was taught to fly to an office, 50 miles away. Meanwhile, the company transferred this same data over the internet to this same office. The pigeon won -- by a long shot.

What a joke this ISP was, right? A BIRD could transfer data faster than them. A bird!

Their internet may or may not have been slow, but this experiment doesn't say much. No matter how fast or slow your internet is, you can select an amount of data that will allow the internet or a pigeon to win.

Here's why: 

How long does it take a pigeon to fly 50 miles with a 10 GB USB stick attached to its leg? Let's say it takes about 3 hours. Great.

Now, how long does it take to transfer 10 GB on the internet? Let's say you have pretty fast internet, and 10 GB only took 30 minutes. Okay, then transfer 100 GB and you know it will take more than 3 hours.

How long does it take that same pigeon to "transfer" 100 GB? Still 3 hours. The pigeon's transfer speed doesn't depend on the amount of data. (USB sticks are pretty light but can fit a ton of data.)

So, just like that: the pigeon beat the internet!

The pigeon's transfer time is constant. The internet's transfer time is proportional to the amount of data: twice the data will take about twice as much time.

In Big-O time, we'd say that the pigeon takes O(1) time. This means that the time it takes to transfer N gigabytes varies proportionally with 1. That is, it doesn't vary at all.

The internet's transfer speed is O(N). This means that the amount of time it takes varies proportionally with N.

Now, what if you had something that was O(N^2)? This would mean that the time varies with the size of N squared.

A real life example of an O(N^2) problem would be the time it takes to paint a square wall of length N (note: N is the length of the wall, not the area of the wall). If I make the edge of my square twice as long, the area of the square wall increases 4x.

Big-O offers an equation to describe how the time of a procedure changes relative to its input. It describes the trend. It does not define exactly how long it takes, as a procedure with a larger big-O time than another procedure could be faster on specific inputs.

Notes: https://stackoverflow.com/questions/487258/what-is-a-plain-english-explanation-of-big-o-notation

The best example of Big-O I can think of is doing arithmetic. Take two numbers (123456 and 789012). The basic arithmetic operations we learnt in school were:

addition;
subtraction;
multiplication; and
division.
Each of these is an operation or a problem. A method of solving these is called an algorithm.

Addition is the simplest. You line the numbers up (to the right) and add the digits in a column writing the last number of that addition in the result. The 'tens' part of that number is carried over to the next column.

Let's assume that the addition of these numbers is the most expensive operation in this algorithm. It stands to reason that to add these two numbers together we have to add together 6 digits (and possibly carry a 7th). If we add two 100 digit numbers together we have to do 100 additions. If we add two 10,000 digit numbers we have to do 10,000 additions.

See the pattern? The complexity (being the number of operations) is directly proportional to the number of digits n in the larger number. We call this O(n) or linear complexity.

Subtraction is similar (except you may need to borrow instead of carry).

Multiplication is different. You line the numbers up, take the first digit in the bottom number and multiply it in turn against each digit in the top number and so on through each digit. So to multiply our two 6 digit numbers we must do 36 multiplications. We may need to do as many as 10 or 11 column adds to get the end result too.

If we have two 100-digit numbers we need to do 10,000 multiplications and 200 adds. For two one million digit numbers we need to do one trillion (1012) multiplications and two million adds.

As the algorithm scales with n-squared, this is O(n2) or quadratic complexity. This is a good time to introduce another important concept:

The Telephone Book
The next best example I can think of is the telephone book, normally called the White Pages or similar but it'll vary from country to country. But I'm talking about the one that lists people by surname and then initials or first name, possibly address and then telephone numbers.

Now if you were instructing a computer to look up the phone number for "John Smith" in a telephone book that contains 1,000,000 names, what would you do? Ignoring the fact that you could guess how far in the S's started (let's assume you can't), what would you do?

A typical implementation might be to open up to the middle, take the 500,000th and compare it to "Smith". If it happens to be "Smith, John", we just got real lucky. Far more likely is that "John Smith" will be before or after that name. If it's after we then divide the last half of the phone book in half and repeat. If it's before then we divide the first half of the phone book in half and repeat. And so on.

This is called a binary search and is used every day in programming whether you realize it or not.

So if you want to find a name in a phone book of a million names you can actually find any name by doing this at most 20 times. In comparing search algorithms we decide that this comparison is our 'n'.

For a phone book of 3 names it takes 2 comparisons (at most).
For 7 it takes at most 3.
For 15 it takes 4.
…
For 1,000,000 it takes 20.
That is staggeringly good isn't it?

In Big-O terms this is O(log n) or logarithmic complexity. Now the logarithm in question could be ln (base e), log10, log2 or some other base. It doesn't matter it's still O(log n) just like O(2n2) and O(100n2) are still both O(n2).

It's worthwhile at this point to explain that Big O can be used to determine three cases with an algorithm:

Best Case: In the telephone book search, the best case is that we find the name in one comparison. This is O(1) or constant complexity;
Expected Case: As discussed above this is O(log n); and
Worst Case: This is also O(log n).
Normally we don't care about the best case. We're interested in the expected and worst case. Sometimes one or the other of these will be more important.

Back to the telephone book.

What if you have a phone number and want to find a name? The police have a reverse phone book but such look-ups are denied to the general public. Or are they? Technically you can reverse look-up a number in an ordinary phone book. How?

You start at the first name and compare the number. If it's a match, great, if not, you move on to the next. You have to do it this way because the phone book is unordered (by phone number anyway).

So to find a name given the phone number (reverse lookup):

Best Case: O(1);
Expected Case: O(n) (for 500,000); and
Worst Case: O(n) (for 1,000,000).

The Travelling Salesman
This is quite a famous problem in computer science and deserves a mention. In this problem you have N towns. Each of those towns is linked to 1 or more other towns by a road of a certain distance. The Travelling Salesman problem is to find the shortest tour that visits every town.

Sounds simple? Think again.

If you have 3 towns A, B and C with roads between all pairs then you could go:

A ? B ? C
A ? C ? B
B ? C ? A
B ? A ? C
C ? A ? B
C ? B ? A
Well actually there's less than that because some of these are equivalent (A ? B ? C and C ? B ? A are equivalent, for example, because they use the same roads, just in reverse).

In actuality there are 3 possibilities.

Take this to 4 towns and you have (iirc) 12 possibilities.
With 5 it's 60.
6 becomes 360.
This is a function of a mathematical operation called a factorial. Basically:

5! = 5 × 4 × 3 × 2 × 1 = 120
6! = 6 × 5 × 4 × 3 × 2 × 1 = 720
7! = 7 × 6 × 5 × 4 × 3 × 2 × 1 = 5040
…
25! = 25 × 24 × … × 2 × 1 = 15,511,210,043,330,985,984,000,000
…
50! = 50 × 49 × … × 2 × 1 = 3.04140932 × 1064
So the Big-O of the Travelling Salesman problem is O(n!) or factorial or combinatorial complexity.

By the time you get to 200 towns there isn't enough time left in the universe to solve the problem with traditional computers.

Something to think about.

Polynomial Time
Another point I wanted to make quick mention of is that any algorithm that has a complexity of O(na) is said to have polynomial complexity or is solvable in polynomial time.

O(n), O(n2) etc are all polynomial time. Some problems cannot be solved in polynomial time. Certain things are used in the world because of this. Public Key Cryptography is a prime example. It is computationally hard to find two prime factors of a very large number. If it wasn't, we couldn't use the public key systems we use.

Anyway, that's it for my (hopefully plain English) explanation of Big O (revised).