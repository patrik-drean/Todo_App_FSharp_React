import { all, call, put, takeEvery, select } from 'redux-saga/effects';
import {ADD_TASK, ADD_TASK_SAGA, DELETE_TASK, DELETE_TASK_SAGA} from "../actions/actions";

export function* createNewTask(action) {
    const tasks = yield select(state => state.tasks);
    const nextId = tasks[tasks.length-1].id + 1; //TODO
    const newTask = { id: nextId, description: action.payload.taskDescription };
    
    yield fetch(`api/Tasks/`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newTask)
    });
    
    yield put({type: ADD_TASK, payload: {newTask}})
}

export function* deleteNewTask(action) {
    const tasks = yield select(state => state.tasks); 
    const updatedTasks = tasks.filter(task => {
        return task.id !== action.payload.id;
    });

    yield fetch(`api/Tasks/${action.payload.id}`, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
    });
    
    yield put({type: DELETE_TASK, payload: {updatedTasks}})
}

export function* createNewTaskWatch() {
    yield takeEvery(ADD_TASK_SAGA, createNewTask)   
}

export function* deleteNewTaskWatch() {
    yield takeEvery(DELETE_TASK_SAGA, deleteNewTask);
}

export default function* rootSaga() {
    yield all([
        call(createNewTaskWatch),
        call(deleteNewTaskWatch),
    ])
}