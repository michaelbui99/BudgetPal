import { PayloadAction, createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { User } from './model/user';

export interface UserState {
    currentUser: User | undefined;
}

export type SignUpUserPayload = {
    email: string;
    password: string;
};

const initialState: UserState = {
    currentUser: undefined,
};

export const createUser = createAsyncThunk<void, SignUpUserPayload>(
    'user/createUser',
    async (payload: SignUpUserPayload, { dispatch }) => {
        const baseUrl = 
    }
);

export const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        loginUser: (_: UserState, action: PayloadAction<User>) => {
            return {
                currentUser: action.payload,
            };
        },
        logoutUser: () => {
            return {
                currentUser: undefined,
            };
        },
    },
});
