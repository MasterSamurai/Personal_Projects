# Problem 9
"""There exists exactly one Pythagorean triplet for which a + b + c = 1000. Find the product abc."""
def pythagorean_Triplet(sum):
    for i in range(1, sum):
        for j in range(sum-i):
            k = 1000-i-j
            if i**2+j**2 == k**2:
                return i*j*k
