# Problem 34:
"""Find the sum of all numbers which are equal to the sum of the factorial of their digits. Note: as 1! = 1 and 2! = 2 are not sums they are not included."""
def factorial(num):
    fact = 1
    for i in range(num,1,-1):
        fact *= i
    return fact

def sumDigitFactorialsEqualsNumber(num):
    digits = [int(d) for d in str(num)]
    if sum([factorial(d) for d in digits]) == num and len(digits) > 1:
        return True
    else:
        return False

def digitFactorials():
    return sum([i for i in range(3,100000) if sumDigitFactorialsEqualsNumber(i)])
