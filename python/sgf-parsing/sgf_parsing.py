import re

class SgfTree(object):
    def __init__(self, properties=None, children=None):
        self.properties = properties or {}
        self.children = children or []

    def __eq__(self, other):
        if not isinstance(other, SgfTree):
            return False
        for k, v in self.properties.items():
            if k not in other.properties:
                return False
            if other.properties[k] != v:
                return False
        for k in other.properties.keys():
            if k not in self.properties:
                return False
        if len(self.children) != len(other.children):
            return False
        for a, b in zip(self.children, other.children):
            if a != b:
                return False
        return True


def parse(input_string):
    tree = SgfTree()
    pointer = tree
    stack = []
    trees = []
    state = 0
    key, value = "", []
    for i in range(len(input_string)):
        if input_string[i] == '(':
            stack.append(input_string[i])
            if state == 0:
                state = 1
                trees.append(pointer)
            elif state == 6 or state == 7:
                pointer.children.append(SgfTree())
                trees.append(pointer)
                pointer = pointer.children[-1]
                value = []
                state = 1
            else:
                raise ValueError("Illegal state transition 1")
        elif input_string[i] == ';':
            if state == 6:
                pointer.children.append(SgfTree())
                trees.append(pointer)
                pointer = pointer.children[-1]
                value = []
                state = 2
            elif state != 1:
                raise ValueError("Illegal state transition 2")
            else:
                state = 2
        elif input_string[i] == '[':
            stack.append(input_string[i])
            if state == 3 or state == 6:
                state = 4
            else:
                raise ValueError("Illegal state transition 4")
        elif re.match(r"[a-z]|[0-9]|[A-Z]",input_string[i]):
            if state == 4:
                inner_value = input_string[i]
                state = 5
            elif state == 5:
                inner_value += input_string[i]
            elif state == 2 or state == 6:
                if re.match(r"[A-Z]",input_string[i]):
                    key = input_string[i]
                    state = 3
                else:
                    raise ValueError("Illegal state transition")
            elif state == 3:
                if re.match(r"[A-Z]",input_string[i]):
                    key += input_string[i]
                else:
                    raise ValueError("Illegal state transition")
            else:
                raise ValueError("Illegal state transition 5")
        elif input_string[i] == ')':
            if state == 2 or state == 6:
                pointer = trees.pop()
            else:
                raise ValueError("Illegal state transition 6")
            if stack.pop() != '(':
                raise Exception("Imbalanced brackets")
        elif input_string[i] == ']':
            if state != 5:
                raise ValueError("Illegal state transition 7")
            else:
                value.append(inner_value)
                pointer.properties[key]=value   
                state = 6
            if stack.pop() != '[':
                raise Exception("Imbalanced brackets")
    if stack:
        raise Exception("Imbalanced brackets")
    return tree