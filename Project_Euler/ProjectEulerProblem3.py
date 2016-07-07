# Problem 3
"""What is the largest prime factor of the number 600851475143 ?"""
def largest_prime_factor(num):
    return max([i for i in range(2, (int(num**0.5) + 1)) if num % i == 0 and all(i % x != 0 for x in range(2,i))])
