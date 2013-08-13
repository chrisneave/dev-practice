require "test/unit"

module KataTwo
  class TestClass < Test::Unit::TestCase
    def chop(int, array_of_int)
      return -1 if array_of_int.length == 0
      
      if array_of_int.length == 1
        return 0 if int == array_of_int[0]
        return -1
      end

      if array_of_int.length == 2
        return 0 if int == array_of_int[0]
        return 1 if int == array_of_int[1]
        return -1
      end

      #Loop splitting the array until only a single element is left.
      sub_array = array_of_int
      current_index = nil
      counter = 0
      until counter > 10 || sub_array.length <= 2 do
        middle = sub_array.length / 2

        break if sub_array.length == 0
        if !current_index.nil?
          break if int == sub_array[current_index]
        end

        return -1 if int < sub_array[0] || int > sub_array[sub_array.length - 1]

        if int > sub_array[middle]
          # Right side of array
          sub_array = take_after(middle, sub_array)
          if current_index.nil?
            current_index = middle + 1
          else
            current_index += middle
          end
        else
          # Left side of array
          sub_array = take_up_to(middle, sub_array)
          if current_index.nil?
            current_index = middle
          else
            current_index -= middle
          end
        end

        counter += 1
      end

      if sub_array.length == 1
        return current_index if int == sub_array[0]
        return -1
      end

      if sub_array.length == 2
        return current_index - 1if int == sub_array[0]
        return current_index if int == sub_array[1]
        return -1
      end

      return -1 if int != sub_array[0] && sub_array.length == 1
      return current_index
    end

    def take_up_to(index, array)
      return [] if index < 0
      rv = []
      array.each_index do |i|
        rv << array[i] if i <= index
      end
      rv
    end

    def take_after(index, array)
      return [] if index >= array.length
      rv = []
      array.each_index do |i|
        rv << array[i] if i > index
      end
      rv
    end

    def test_take_up_to
      assert_equal([], take_up_to(1, []))
      assert_equal([1], take_up_to(0, [1,2,3]))
      assert_equal([1,2], take_up_to(1, [1,2,3]))
      assert_equal([1,2,3], take_up_to(2, [1,2,3]))
      assert_equal([1,2,3], take_up_to(3, [1,2,3]))
    end

    def test_take_after
      assert_equal([], take_after(1, []))
      assert_equal([1,2,3], take_after(-1, [1,2,3]))
      assert_equal([2,3], take_after(0, [1,2,3]))
      assert_equal([3], take_after(1, [1,2,3]))
      assert_equal([], take_after(2, [1,2,3]))
    end

    def test_chop
      assert_equal(-1, chop(3, []))
      assert_equal(-1, chop(3, [1]))
      assert_equal(0,  chop(1, [1]))
      #
      assert_equal(0,  chop(1, [1, 3, 5]))
      assert_equal(1,  chop(3, [1, 3, 5]))
      assert_equal(2,  chop(5, [1, 3, 5]))
      assert_equal(-1, chop(0, [1, 3, 5]))
      assert_equal(-1, chop(2, [1, 3, 5]))
      assert_equal(-1, chop(4, [1, 3, 5]))
      assert_equal(-1, chop(6, [1, 3, 5]))
      #
      assert_equal(0,  chop(1, [1, 3, 5, 7]))
      assert_equal(1,  chop(3, [1, 3, 5, 7]))
      assert_equal(2,  chop(5, [1, 3, 5, 7]))
      assert_equal(3,  chop(7, [1, 3, 5, 7]))
      assert_equal(-1, chop(0, [1, 3, 5, 7]))
      assert_equal(-1, chop(2, [1, 3, 5, 7]))
      assert_equal(-1, chop(4, [1, 3, 5, 7]))
      assert_equal(-1, chop(6, [1, 3, 5, 7]))
      assert_equal(-1, chop(8, [1, 3, 5, 7]))
    end
  end
end

