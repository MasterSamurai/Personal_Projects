# Problem 12
"""What is the value of the first triangle number to have over five hundred divisors?"""
def triangle_Number(num):
    if ((8*num +1)**0.5).is_integer() == True:
        return True
    else:
        return False

def divisor_Count(num):
    return sum([2 for i in range(1, int((num+1)**0.5)) if num % i == 0])

def divisor_Number(divisor_limit):
    num = 0
    for i in range(0,100000000000000,divisor_limit):
        if triangle_Number(i) == True:
            if divisor_Count(i) > divisor_limit:
                num = i
                break
    return num
