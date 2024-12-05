import re

def read_file():
    with open('03_Input.txt', 'r') as file:
        row = file.readlines()
    return row

def Expression(records, pattern):
    mul_exp = []
    numbers = []
    total = 0
    do = True

    for record in records:
        mul_exp += re.findall(pattern, record)

    num_pattern = r"\d{1,3}|do|don\'t"
    for mul in mul_exp:
        if mul == "do()" : do = True
        elif mul == "don't()" : do = False
        else:
            if do : numbers += re.findall(num_pattern, mul)
            if len(numbers) == 2 : 
                total += int(numbers[0]) * int(numbers[1])
                numbers.clear()
    
    return total

#-------------------------------------------------------------------------------
#MAIN

records = read_file()
#row = ["xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"]

#part_1
mul_pattern = r"mul\(\d{1,3},\d{1,3}\)"
mul_total = Expression(records, mul_pattern)

#part_2
do_pattern = r"mul\(\d{1,3},\d{1,3}\)|do\(\)|don\'t\(\)"
do_total = Expression(records, do_pattern)

print(mul_total)
print(do_total)

#END   
