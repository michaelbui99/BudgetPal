import { AtSignIcon, ChevronDownIcon } from '@chakra-ui/icons';
import {
    Box,
    Button,
    Menu,
    MenuButton,
    MenuItem,
    MenuList,
} from '@chakra-ui/react';
import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../store';
import { selectBudget } from '../../features/budget/budgetSlice';

interface BudgetSelectorProps {
    styles?: React.CSSProperties;
}

const BudgetSelector: React.FC<BudgetSelectorProps> = ({ styles }) => {
    const DEFAULT_TEXT = 'Select Budget';
    const budgetState = useSelector((state: RootState) => state.budget);
    const dispatch = useDispatch();

    return (
        <Box textAlign="center" style={styles} width="100%">
            <Menu>
                <MenuButton
                    leftIcon={<AtSignIcon />}
                    as={Button}
                    width="100%"
                    rightIcon={<ChevronDownIcon />}
                >
                    {budgetState.currentBudget
                        ? budgetState.currentBudget.name
                        : DEFAULT_TEXT}
                </MenuButton>
                <MenuList>
                    {budgetState.allBudgets.map((budget) => (
                        <MenuItem
                            key={budget.id}
                            onClick={() => dispatch(selectBudget(budget))}
                        >
                            {budget.name}
                        </MenuItem>
                    ))}
                </MenuList>
            </Menu>
        </Box>
    );
};

export default BudgetSelector;
