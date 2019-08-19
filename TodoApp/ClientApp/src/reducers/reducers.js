import {ADD_TASK, DELETE_TASK, GET_ALL_TASKS} from '../actions/actions';

const initialState = {
    tasks: [],
};

const reducer = function (state = initialState, action) {
    switch (action.type) {
        case GET_ALL_TASKS:
            return {
                tasks: action.payload.tasks,
            };
        case ADD_TASK:
            return {
                tasks: [...state.tasks, action.payload.newTask],
            };
        case DELETE_TASK:
            return {
                tasks: action.payload.updatedTasks,
            };
        default:
            return state;
    }
};

export default reducer;