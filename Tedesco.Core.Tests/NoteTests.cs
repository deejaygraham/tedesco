using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tedesco.Tests
{
    public class NoteTests
    {
        [Fact]
        public void Note_Negative_Values_Are_Not_Allowed()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new Note(-1);
            });
        }

        [Fact]
        public void Note_Distance_Between_Adjacent_Notes_Is_HalfStep()
        {
            Assert.Equal(1, (new Note(20) - new Note(19)).Semitones);
        }

        [Fact]
        public void Note_Distance_Between_White_Notes_Is_WholeStep()
        {
            Assert.Equal(-2, (new Note(50) - new Note(52)).Semitones);
        }

        [Fact]
        public void Note_Plus_Positive_Interval_Gives_Higher_Note()
        {
            Assert.Equal(new Note(51), (new Note(50) + new Interval(1)));
        }

        [Fact]
        public void Note_Plus_Negative_Interval_Gives_Lower_Note()
        {
            Assert.Equal(new Note(49), (new Note(50) + new Interval(-1)));
        }

        [Fact]
        public void Note_Sharpening_Leaves_Original_Note_Unchanged()
        {
            var note = new Note(50);

            note.Sharpen();

            Assert.Equal(new Note(50), note);
        }

        [Fact]
        public void Note_Sharpening_Returns_Next_Highest_Note()
        {
            var note = new Note(50);

            var sharper = note.Sharpen();

            Assert.True(sharper > note);
        }

        [Fact]
        public void Note_Flattening_Leaves_Original_Note_Unchanged()
        {
            var note = new Note(50);

            note.Flatten();

            Assert.Equal(new Note(50), note);
        }

        [Fact]
        public void Note_Flattening_Returns_Next_Lowest_Note()
        {
            var note = new Note(50);

            var flatter = note.Flatten();

            Assert.True(flatter < note);
        }

        [Fact]
        public void Note_Same_Note_In_Different_Octaves_Are_Related()
        {
            Assert.True(new Note(40).RelatedTo(new Note(52)));
        }

        [Fact]
        public void Note_Different_Notes_In_Same_Octave_Are_Unrelated()
        {
            Assert.False(new Note(40).RelatedTo(new Note(42)));
        }

        [Fact]
        public void Note_Different_Notes_In_Different_Octaves_Are_Unrelated()
        {
            Assert.False(new Note(40).RelatedTo(new Note(53)));
        }

        [Fact]
        public void Note_Same_Note_Values_Are_Equal()
        {
            var left = new Note(40);
            var right = new Note(39) + new Interval(1);

            Assert.True(left == right);
        }

        [Fact]
        public void Note_Different_Note_Values_Are_Not_Equal()
        {
            Assert.False(new Note(40) == new Note(53));
            Assert.True(new Note(40) != new Note(53));
        }

    }
}
