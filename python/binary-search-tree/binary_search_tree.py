class TreeNode(object):
    def __init__(self, data, left, right):
        self.data = data
        self.left = left
        self.right = right

    def __str__(self):
        fmt = 'TreeNode(data={}, left={}, right={})'
        return fmt.format(self.data, self.left, self.right)

    def insert(self,data):
        if self.data:
            if float(data) <= float(self.data):
                if self.left == None:
                    self.left = TreeNode(data,None,None)
                else:
                    self.left.insert(data)
            if float(data) > float(self.data):
                if self.right == None:
                    self.right = TreeNode(data,None,None)
                else:
                    self.right.insert(data)
        else:
            self.data=data

    def sort(self,sorted):
        if self.left:
            self.left.sort(sorted)
            
        sorted.append(self.data)

        if self.right:
            self.right.sort(sorted)
        
        


class BinarySearchTree(object):
    def __init__(self, tree_data):
        self.tree = TreeNode(None,None,None)
        for i in tree_data:
            self.tree.insert(i)

    def data(self):
        return self.tree

    def sorted_data(self):
        sorted = []
        self.tree.sort(sorted)
        return sorted
