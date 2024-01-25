import React from 'react';
import { NavTarget } from './nav-target';
import { Box, Button, Text } from '@chakra-ui/react';
import { colors } from '../../colors';
import { CalendarIcon } from '@chakra-ui/icons';
import { useNavigate } from 'react-router-dom';

interface NavItemProps {
    onClick?: (item: NavTarget) => any;
    item: NavTarget;
    active: boolean;
}

const NavItem: React.FC<NavItemProps> = ({ item, active, onClick }) => {
    const navigate = useNavigate();

    return (
        <Box
            textAlign="center"
            cursor="pointer"
            transition="all 0.2s ease-in-out"
            padding="0.5rem"
            backgroundColor={active ? colors.LIGHT_ACCENT : colors.BG_MAIN}
            _hover={{
                backgroundColor: colors.LIGHT_ACCENT,
                color: colors.BG_MAIN,
            }}
            onClick={() => {
                navigate(item.redirectTo);
                if (onClick) {
                    onClick(item);
                }
            }}
            width="100%"
            fontWeight={active ? 'bold' : 'normal'}
        >
            <Text color={colors.NORMAL_TEXT}>{item.name}</Text>
        </Box>
    );
};

export default NavItem;
