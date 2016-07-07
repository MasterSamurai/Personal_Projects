# Problem 4
"""Find the largest palindrome made from the product of two 3-digit numbers."""
def largest_palindrome(digits):
    c = 0
    for i in range(int('9' * (digits-1)), int('9' * digits)):
        for k in range(int('9' * (digits-1)), int('9' * digits)):
            if str(i * k) == str(i * k)[::-1] and (i * k) > c:
                c = i * k
    return c
