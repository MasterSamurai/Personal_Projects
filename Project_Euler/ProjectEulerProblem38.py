# Problem 38:
"""What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2, ... , n) where n > 1?"""
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
    if digits.count(0) != 0:
        return False
    return True

def largestPandigitalMultiple():
    largest = 0
    for i in range(10000,1,-1):
        for j in range(2,10):
            string = ''
            for k in range(1,j):
                string += str(i*k)
            if containsAllDigitsOnce(int(string)) and int(string) > largest:
                largest = int(string)
    return largest
