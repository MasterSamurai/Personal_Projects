# Problem 30:
"""Find the sum of all the numbers that can be written as the sum of fifth powers of their digits."""
def digit_Powers(power):
    return sum([i for i in range(10,200000) if sum([j**power for j in map(int,'%s' % i)]) == i])
