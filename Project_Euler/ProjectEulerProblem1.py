# Problem 1
"""Find the sum of all the multiples of 3 or 5 below 1000."""
def find_sum_of_multiples(limit, *multiples):
    return sum([i for i in range(limit) if any(i % j == 0 for j in multiples)])
