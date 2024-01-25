import React, { useState } from 'react';
import { NavTarget } from './nav-target';
import { Flex } from '@chakra-ui/react';
import NavItem from './NavItem';

export interface NavItemListProps {
    navItems: NavTarget[];
}

const NavItemList: React.FC<NavItemListProps> = ({ navItems }) => {
    const [activeItem, setActiveItem] = useState<NavTarget | undefined>(
        undefined
    );

    const handleNavItemClick = (item: NavTarget) => {
        if (activeItem && item === activeItem) {
            setActiveItem(undefined);
            return;
        }
        setActiveItem(item);
    };

    return (
        <Flex>
            {navItems.map((navItem) => (
                <NavItem
                    active={activeItem === navItem}
                    onClick={handleNavItemClick}
                    item={navItem}
                    key={navItem.name}
                />
            ))}
        </Flex>
    );
};

export default NavItemList;
