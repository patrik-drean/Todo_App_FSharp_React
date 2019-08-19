import {ADD_TASK, DELETE_TASK} from "../actions/actions";

const initialState = {
    tasks: [{ id: 1, description: 'Hardcoded Value' }]
};

const reducer = function (state = initialState, action) {
    switch (action.type) {
        case ADD_TASK:
            return {
                tasks: [...state.tasks, action.payload.newTask]
            };
        case DELETE_TASK:
            return {
                tasks: action.payload.updatedTasks
            };
        default:
            return state;
    }
};

export default reducer;