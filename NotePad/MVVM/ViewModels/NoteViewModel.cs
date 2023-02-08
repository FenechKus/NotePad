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

        public string Title
        {
            get => note.Title;
            set
            {
                note.Title = value;
                OnPropertyChanged();
            }
        }

        public string Description
        { 
            get => note.Description;
            set
            {
                note.Description = value;
                OnPropertyChanged();
            } 
        }

        public DateTime DateCreate 
        {
            get => note.DateCreate;
            set
            {
                note.DateCreate = value;
                OnPropertyChanged();
            }
        }

        public NoteViewModel(Note note)
        {
            this.note = note;
        }
    }
}
