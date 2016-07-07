# Problem 2
"""By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms."""
def find_even_fibonnacci_sum(limit):
    a, b, c = 0, 1, [0]
    while b <= limit:
      a, b = b, a + b
        c.append(b)
    return sum([d for d in c if d % 2 == 0])
