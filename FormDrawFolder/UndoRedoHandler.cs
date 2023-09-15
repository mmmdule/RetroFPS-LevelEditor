using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelEditor.FormDrawFolder {
    internal class UndoRedoHandler {
        private Stack<List<MapObject>> undoStack;
        private Stack<List<MapObject>> redoStack;
        public UndoRedoHandler() {
            undoStack = new Stack<List<MapObject>>();//initialize stack
            redoStack = new Stack<List<MapObject>>();//initialize stack
        }

        public void AddMove(List<MapObject> list) {
            //if the undo stack is more than 10, pop the bottom one
            if(undoStack.Count == 10) {
                //remove the bottom one
                undoStack = new Stack<List<MapObject>>(undoStack.Take(9));
            }

            //push the current list onto the undo stack
            undoStack.Push(list);
            //clear the redo stack
            redoStack.Clear();
        }

        public List<MapObject> Undo(List<MapObject> list) {
            //pop the undo stack
            //set the map object list to the popped list
            //push the popped list onto the redo stack
            //redoStack.Clear();
            redoStack.Push(new List<MapObject>(list));
            return undoStack.Pop();
        }

        public List<MapObject> Redo() {
            if (redoStack.Count == 10) {
                //remove the bottom one
                redoStack = new Stack<List<MapObject>>(undoStack.Take(9));
            }
            //pop the redo stack
            //set the map object list to the popped list
            //push the popped list onto the undo stack
            undoStack.Push(new List<MapObject>(redoStack.Peek()));
            return redoStack.Pop();
        }

        public bool CanUndo() {
            //return true if the undo stack is not empty
            return undoStack.Count > 0;
        }

        public bool CanRedo() {
            //return true if the redo stack is not empty
            return redoStack.Count > 0;
        }
    }
}
