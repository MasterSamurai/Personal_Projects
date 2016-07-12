# Problem 25:
"""What is the index of the first term in the Fibonacci sequence to contain 1000 digits?"""
def nth_Digit_Fibbonacci(num_digits):
    a,b,i,l = 1,1,2,0
    while l < num_digits:
        i += 1
        a,b = b,a+b
        l = len(str(b))
    return i
