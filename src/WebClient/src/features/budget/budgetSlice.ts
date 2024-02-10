import { PayloadAction, createSlice } from '@reduxjs/toolkit';
import { Budget } from './model/budget';

export interface BudgetState {
    currentBudget: Budget | undefined;
    allBudgets: Budget[];
}

const initialState: BudgetState = {
    currentBudget: undefined,
    allBudgets: [
        {
            id: 'test',
            name: 'Budget 1',
        },
        {
            id: 'test2',
            name: 'Budget 2',
        },
    ],
};

export const budgetSlice = createSlice({
    name: 'budget',
    initialState,
    reducers: {
        selectBudget: (state: BudgetState, action: PayloadAction<Budget>) => {
            state.currentBudget = action.payload;
        },
    },
});

export const { selectBudget } = budgetSlice.actions;
export default budgetSlice.reducer;
