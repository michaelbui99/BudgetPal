import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App.tsx';
import './index.css';
import { ChakraProvider } from '@chakra-ui/react';
import { RouterProvider } from 'react-router-dom';
import { router } from './routing.ts';
import theme from './theme.ts';
import { Provider } from 'react-redux';
import { store } from './store.ts';

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <ChakraProvider theme={theme} resetCSS>
            <Provider store={store}>
                <RouterProvider router={router} />
            </Provider>
        </ChakraProvider>
    </React.StrictMode>
);
