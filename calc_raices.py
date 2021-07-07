from requests import NullHandler


num_list = list()

def main():
    while True:
        print("choose option: \n",
        "1: get root \n",
        "2: enter list \n",
        "3: get list root \n",
        "4: split list and get roots \n",
        "0: quit \n")
        textInput = str(input())
        if textInput == '0':
            exit()
        elif textInput == '1':
            num = getNumber()
            if num != False:
                print("Unitary root: " + str(getUnitaryRoot(num)))
        elif textInput == '2':
            enterList()
        elif textInput == '3': 
            print("List's unitary root: "+ str(getListRoot()))
        elif textInput == '4': 
            splitList()

def getNumber(text = True):
    number = ''
    if text:
        print("Enter number, or press enter to leave")
    while True:
        number = input()
        if number.isnumeric():
            return(abs(int(number)))
        elif len(number) == 0:
            return False
        else:
            print("Unvalid input, or press enter to leave")
        
def getUnitaryRoot(number):
    root = 0
    while True:
        root += number % 10
        number = number // 10
        if number == 0:
            if root > 9:
                number = root
                root = 0
            else:
                return root

def enterList():
    num_list.clear()
    print("Enter number for list, press enter to finish\n")
    while True:
        aux = getNumber(False)
        if aux == False:
            break
        else:
            num_list.append(aux)
    return

def getListRoot():
    num = 0
    for n in num_list:
        num += n
    return getUnitaryRoot(num)

def splitList():
    combinations = (1 << len(num_list))
    for i in range(combinations):
        num1 = 0
        num2 = 0
        group1 = ""
        group2 = ""
        for n in range(len(num_list)):
            if (((i >> n) & 1) == 1):
                num1 = num_list[n]
                group1 += str(num1) + " "
            else:
                num2 = num_list[n]
                group2 += str(num2) + " "
        print(group1 + " - " + group2 + " : " + str(getUnitaryRoot(num1)) + " - " + str(getUnitaryRoot(num2)))
    return

main()