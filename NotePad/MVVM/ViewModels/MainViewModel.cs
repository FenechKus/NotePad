﻿using NotePad.MVVM.Commands;
using NotePad.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotePad.MVVM.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<NoteViewModel> notes;
        private NoteViewModel? selectNote;
        //private readonly Note note;
        private readonly RelayCommands addCommand;
        private readonly RelayCommands removeCommand;
        private readonly RelayCommands sortByTitle;
        private readonly RelayCommands sortByTitleDec;

        public MainViewModel()
        {
            notes = new ObservableCollection<NoteViewModel>();
            addCommand = new RelayCommands(Add);
            removeCommand = new RelayCommands(Remove, obj => Notes.Count> 0);
            sortByTitle = new RelayCommands(SortByTitle, obj => Notes.Count > 1);
            sortByTitleDec = new RelayCommands(SortByTitleDec, obj => Notes.Count > 1);
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

        private void Add(object? param)
        {
            Notes.Add(new NoteViewModel(new Note("Безымянный", "")));
        }

        private void Remove(object? param)
        {
            if (SelectNote is null) 
                return;
                Notes.Remove(SelectNote);
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
