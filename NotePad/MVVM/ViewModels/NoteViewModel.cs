using NotePad.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad.MVVM.ViewModels
{
    internal class NoteViewModel : BaseViewModel
    {
        private readonly Note note;

        public Note Note
        {
            get { return note; }
        }

        public string Title
        {
            get => note.Title;
            set
            {
                note.Title = value;
                OnPropertyChanged();
            }
        }

        public string Text
        { 
            get => note.Text;
            set
            {
                note.Text = value;
                OnPropertyChanged();
            } 
        }

        public int Id
        {
            get => note.Id;
            set
            {
                note.Id = value;
                OnPropertyChanged();
            }
        }

        public NoteViewModel(Note note)
        {
            this.note = note;
        }
    }
}
