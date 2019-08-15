import { call, put, takeEvery } from 'redux-saga/effects';

function* addTaskToDB(newTask) {
    
    yield fetch(`api/Tasks/`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newTask)
    });
}