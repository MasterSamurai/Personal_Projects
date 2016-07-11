# Problem 20:
"""Find the sum of the digits in the number 100!"""
def sum_Digits_Factorial(factorial):
    sum, final = 1, 0
    for i in range(factorial,1,-1):
        sum *= i
    for j in str(sum):
        final += int(j)
    return final
