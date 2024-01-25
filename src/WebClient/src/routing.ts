import { RouteObject, createBrowserRouter } from 'react-router-dom';
import IndexPage from './pages/IndexPage';
import BudgetPage from './pages/BudgetPage';

const routes: RouteObject[] = [
    {
        path: '/',
        Component: IndexPage,
    },
    {
        path: '/budget',
        Component: BudgetPage,
    },
];

export const router = createBrowserRouter(routes);
