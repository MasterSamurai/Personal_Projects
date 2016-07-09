# Problem 10
"""Find the sum of all the primes below two million."""
def sum_Of_All_Primes(limit):
    primes, sum_of_nums = [2], 2
    for i in range(3,limit,2):
        for prime in primes:
            if i % prime == 0:
                break
        else:
            primes.append(i)
            sum_of_nums += i
            print(i)
    return sum_of_nums
