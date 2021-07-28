// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		Stage stage;
		[SetUp]
		public void Setup()
        {
			stage = new Stage();
        }

		[Test]
	    public void Ctor_InitializePerformerCollection()
	    {
			stage = new Stage();
			Assert.IsNotNull(stage.Performers);
		}

		[Test]
		public void AddPerformer_ThrowsWhenArgumentIsNull()
        {
			Performer performer = null;

			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
        }

		[Test]
		[TestCase(17)]
		[TestCase(10)]
		public void AddPerformer_ThrowsWhenPerformarAgeAreNotValid(int age)
        {
			Performer performer = new Performer("firstName", "lastName", age);

			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
        }

		[Test]
		public void AddPerformer_AddsPerformerWhenArgumentIsValid()
        {
			Performer performer = new Performer("firstName", "lastName", 18);

			stage.AddPerformer(performer);

			Assert.Contains(performer, (System.Collections.ICollection)stage.Performers);
		}

		[Test]
		public void AddSong_ThrowsWhenSongIsNull()
        {
			Song song = null;

			Assert.Throws<ArgumentNullException>(() => stage.AddSong(song));
        }

		[Test]
		[TestCase(59)]
		[TestCase(40)]
		public void AddSong_ThorwsWhenSongDurationIsInvalid(int sec)
        {
			Song song = new Song("song", new TimeSpan(0, 0, sec));

			Assert.Throws<ArgumentException>(() => stage.AddSong(song));
		}

		[Test]
		public void AddSongToPerformer_ThrowsWhenSongNameIsNull()
        {
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "performer"));
        }

		[Test]
		public void AddSongToPerformer_ThrowsWhenPerformerNameIsNull()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("song", null));
		}

		[Test]
		public void AddSongToPerformer_ThrowsWhenPerformerDoesNotExist()
        {
			Song song = new Song("song", new TimeSpan(0, 1, 40));
			stage.AddSong(song);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("song", "performer"));
		}

		[Test]
		public void AddSongToPerformer_ThrowsWhenSongDoesNotExist()
		{
			Performer performer = new Performer("firstName", "lastName", 18);
			stage.AddPerformer(performer);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("song", performer.FullName));
		}

		[Test]
		public void AddSongToPerformer_ReturnsRightStringWhenArgumentsAreValid()
        {
			Song song = new Song("song", new TimeSpan(0, 1, 40));
			Performer performer = new Performer("firstName", "lastName", 18);
			stage.AddSong(song);
			stage.AddPerformer(performer);

			Assert.That(stage.AddSongToPerformer(song.Name, performer.FullName),
				Is.EqualTo(string.Format("{0} will be performed by {1}", song.ToString(), performer.ToString())));
		}

		[Test]
		[TestCase (5)]
		[TestCase (10)]
		public void Play_ReturnRightString(int n)
        {
            for (int i = 0; i < n; i++)
            {
				Performer performer = new Performer($"firstName{i}", "lastName{i}", 18 + i);
				stage.AddPerformer(performer);
                for (int j = 0; j < n/2; j++)
                {
					Song song = new Song($"Song{i}", new TimeSpan(0, i+1, 0));
					stage.AddSong(song);
					stage.AddSongToPerformer(song.Name, performer.FullName);
				}
			}

			int songsCount = stage.Performers.Sum(p => p.SongList.Count());

			string str = string.Format("{0} performers played {1} songs",
				stage.Performers.Count, songsCount);

			Assert.That(stage.Play, Is.EqualTo(str));
		}
	}
}