using Microsoft.EntityFrameworkCore;
using NotePad.MVVM.Commands;
using NotePad.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotePad.MVVM.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<NoteViewModel> notes;
        private NoteViewModel? selectNote;
        private readonly Note note;
        private readonly RelayCommands addCommand;
        private readonly RelayCommands removeCommand;
        private readonly RelayCommands sortByTitle;
        private readonly RelayCommands sortByTitleDec;
        private readonly RelayCommands saveCommand;

        public MainViewModel()
        {
            notes = new ObservableCollection<NoteViewModel>();
            addCommand = new RelayCommands(Add);
            removeCommand = new RelayCommands(Remove, obj => Notes.Count> 0 && selectNote != null);
            sortByTitle = new RelayCommands(SortByTitle, obj => Notes.Count > 1);
            sortByTitleDec = new RelayCommands(SortByTitleDec, obj => Notes.Count > 1);
            saveCommand = new RelayCommands(Save, obj => selectNote != null);

            using (Test2Context db = new Test2Context())
            {
                notes = new ObservableCollection<NoteViewModel>(db.Notes.Select(i => new NoteViewModel(i)));
            }
        }

        

        public ObservableCollection<NoteViewModel> Notes
        {
            get => notes;
            set => Set(ref notes, value);
        }

        public NoteViewModel? SelectNote
        {
            get => selectNote;
            set => Set(ref selectNote, value);
        }

        public RelayCommands AddCommand
        {
            get => addCommand;
        }

        public RelayCommands RemoveCommand
        {
            get => removeCommand;
        }

        public RelayCommands SortyngByTitleCommand
        {
            get => sortByTitle;
        }
        public RelayCommands SortyngByTitleDecCommand
        {
            get => sortByTitleDec;
        }

        public RelayCommands SaveCommand
        {
            get => saveCommand;
        }

        private void Add(object? param)
        {
            Notes.Add(new NoteViewModel(new Note { Title="Безымянный", Text="" }));
        }

        private void Remove(object? param)
        {
            if (SelectNote is null) 
                return;
            try
            {
                using (var db = new Test2Context())
                {
                    foreach (var item in notes)
                    {
                        if (item.Id == SelectNote.Id)
                        {
                            db.Remove(item.Note);
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception) {}
            finally { Notes.Remove(SelectNote); }
        }

        private void Save(object? obj)
        {
            using (Test2Context db = new Test2Context())
            {
                foreach (var item in notes)
                {
                    if (item.Id == 0)
                    {
                        db.Add(item.Note);
                    }
                    else
                    {
                        db.Entry(item.Note).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();
            }
        }

        private void SortByTitleDec(object? param)
        {
            Notes = new ObservableCollection<NoteViewModel>(Notes.OrderByDescending(i => i.Title));
        }
        private void SortByTitle(object? param)
        {
            Notes = new ObservableCollection<NoteViewModel>(Notes.OrderBy(i => i.Title));
        }
    }
}
