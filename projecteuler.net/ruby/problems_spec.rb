require "problems"

describe "problem1" do
	it "sums the multiples of 3 and 5 that are less than 10" do
		expect(problem1(10)).to eq(23)
	end

	it "sums the multiples of 3 and 5 that are less than 1000" do
		expect(problem1(1000)).to eq(233168)
	end
end

describe "problem2" do
	it "sums the even Fibonacci terms less than 90" do
		expect(problem2(90)).to eq(44)
	end

	it "sums the even Fibonacci terms less than 4000000" do
		expect(problem2(4000000)).to eq(0)
	end
end