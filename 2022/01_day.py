'''--- Day 1: Calorie Counting ---
The Elves take turns writing down the number of Calories contained by the various meals, snacks, rations, etc. that they've brought with them, one item per line. Each Elf separates their own inventory from the previous Elf's inventory (if any) by a blank line.

For example, suppose the Elves finish writing their items' Calories and end up with the following list:

1000
2000
3000

4000

5000
6000

7000
8000
9000

10000
This list represents the Calories of the food carried by five Elves:

The first Elf is carrying food with 1000, 2000, and 3000 Calories, a total of 6000 Calories.
The second Elf is carrying one food item with 4000 Calories.
The third Elf is carrying food with 5000 and 6000 Calories, a total of 11000 Calories.
The fourth Elf is carrying food with 7000, 8000, and 9000 Calories, a total of 24000 Calories.
The fifth Elf is carrying one food item with 10000 Calories.
In case the Elves get hungry and need extra snacks, they need to know which Elf to ask: they'd like to know how many Calories are being carried by the Elf carrying the most Calories. In the example above, this is 24000 (carried by the fourth Elf).

Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?'''


def print_cal(arr):
    for x in arr:
        print(x)

rations = []
cal = 0

# Don't append the last value
'''f = open("01_input1.txt", "r")
for x in f:
    if(x!='\n'):
        cal = cal+int(x)       
    else:
        rations.append(cal)
        cal=0'''


text = open("01_input1.txt", "r")

while True:
    line = text.readline()
    if(line!='\n' and line!=''):
        cal = cal+int(line) 
    elif not line: 
        rations.append(cal)
        break
    else:
        rations.append(cal)
        cal=0

text.close()

rations.sort(reverse=True)
print_cal(rations)
print("Highest total Calories carried by an Elf is: ", rations[0])


'''--- Part Two ---
By the time you calculate the answer to the Elves' question, they've already realized that the Elf carrying the most Calories of food might eventually run out of snacks.

To avoid this unacceptable situation, the Elves would instead like to know the total Calories carried by the top three Elves carrying the most Calories. That way, even if one of those Elves runs out of snacks, they still have two backups.

In the example above, the top three Elves are the fourth Elf (with 24000 Calories), then the third Elf (with 11000 Calories), then the fifth Elf (with 10000 Calories). The sum of the Calories carried by these three elves is 45000.

Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?'''

Top3Cal = rations[0]+rations[1]+rations[2]

print("Total Calories carried by top 3 Elves is: ", Top3Cal)