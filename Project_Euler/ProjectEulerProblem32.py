# Problem 32:
"""Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital."""
def containsAllDigitsOnce(num):
    digits = []
    for digit in [int(x) for x in str(num)]:
        if digit == 0:
            return False
        if digit not in digits:
            digits.append(digit)
        else:
            return False
    for digit in range(1,10):
        if digits.count(digit) != 1:
            return False
    return True

def sumPandigitalFactFamilyProducts():
    products = []
    for i in range(60):
        for j in range(2000):
            k = i*j
            if k % 2 == 0:
                if containsAllDigitsOnce(int(str(k) + str(j) + str(i))) and k not in products:
                    print(i,j,k)
                    products.append(k)
            else:
                continue
    return sum(products), products
