from random import randint

class LuckyBall():
	
	def __init__(self):
		self.nums = []
		while len(self.nums) < 6:
			rand_num = randint(1, 6)
			if not rand_num in self.nums:
				self.nums.append(rand_num)


	def __getitem__(self, index):
		return self.nums[index]

	def __len__(self):
		return len(self.nums)

if __name__ == '__main__':
	lotto = LuckyBall()
	for num in range(len(lotto)):
		print('The number with index %s is %i' % (num, lotto[num]))

	print('The lastnumber is %i' % lotto[-1])
	print('The first number is %i' % lotto[0])
	print('The second number is %i' % lotto.__getitem__(1))

	for num in lotto:
		print(num)

