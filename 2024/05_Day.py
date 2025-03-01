import re

def ReadFile():
    with open('05_Input.txt', 'r') as file:
        rows = file.readlines()
    return rows

def SplitFile(rows):
    priorities = []
    print_orders = []
    prio_pattern =r"\d{2}\|\d{2}"
    ord_pattern = r"(?:\d{2},)+\d{2}"

    for r in rows:
        priorities += re.findall(prio_pattern, r)
        print_orders += re.findall(ord_pattern, r)
        #print (r)

    result = CalculatePrinter(priorities, print_orders)
    return result


def CalculatePrinter(priorities, print_orders):
    return


#-------------------------------------------------------------------------------
#MAIN

rows = ReadFile()
sample = ["47|53",
          "97|13",
          "97|61",
          "97|47",
          "75|29",
          "61|13",
          "75|53",
          "29|13",
          "97|29",
          "53|29",
          "61|53",
          "97|53",
          "61|29",
          "47|13",
          "75|47",
          "97|75",
          "47|61",
          "75|61",
          "47|29",
          "75|13",
          "53|13",
          "",
          "75,47,61,53,29",
          "97,61,53,29,13",
          "75,29,13",
          "75,97,47,61,53",
          "61,13,29",
          "97,13,75,29,47"]

priorities, print_orders = SplitFile(sample)

print("Priorities:", priorities)
print("Print Orders:", print_orders)
#END 
