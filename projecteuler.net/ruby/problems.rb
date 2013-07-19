
def problem1(number)
	total = 0
	(1..number - 1).each do |num|
		total += num if num % 3 == 0
		total += num if num % 5 == 0 unless num % 3 == 0
	end
	total
end

def problem2(number)
	total = 0
	calc_fibonacci_term = lambda { |num1, num2| num1 + num2 }
	terms = [1, 2]
	while terms[-1] < number do
		term = calc_fibonacci_term.call(terms[-2], terms[-1])
		break if term >= number
		terms << term
	end

	terms.each do |num|
		total += num if num.even?
	end

	total
end
