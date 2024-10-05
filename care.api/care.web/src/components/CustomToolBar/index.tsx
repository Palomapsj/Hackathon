import { GridApi, GridExportMenuItemProps, GridToolbarContainer, GridToolbarExportContainer, gridFilteredSortedRowIdsSelector, gridVisibleColumnFieldsSelector, useGridApiContext } from "@mui/x-data-grid"
import { CustomToolBarProps } from "./types"
import { ButtonProps, MenuItem } from "@mui/material";
import ExcelJS from 'exceljs'

const getExcel = (apiRef: React.MutableRefObject<GridApi>) => {
    // Select rows and columns
    const filteredSortedRowIds = gridFilteredSortedRowIdsSelector(apiRef);
    const visibleColumnsField = gridVisibleColumnFieldsSelector(apiRef);

    // Create a new workbook
    const workbook = new ExcelJS.Workbook();
    const worksheet = workbook.addWorksheet('Export') // Todo: Passar o valor do nome da WorkSheet conforme viewName / profileName

    // Add column headers
    const columns = visibleColumnsField.map((column) => ({ header: column, key: column }));
    worksheet.columns = columns;

    // Add rows
    const rows = filteredSortedRowIds.map((id) => {
        const row: Record<string, any> = {};
        visibleColumnsField.forEach((field) => {
            row[field] = apiRef.current.getCellParams(id, field).value;
        });
        return row;
    });
    worksheet.addRows(rows);

    // Write the workbook to a buffer
    return workbook.xlsx.writeBuffer();
};

const exportBlob = (buffer: ArrayBuffer, filename: string) => {
    // Save the buffer in an Excel file
    const blob = new Blob([buffer], { type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" });
    const url = URL.createObjectURL(blob);

    const a = document.createElement("a");
    a.href = url;
    a.download = filename;
    a.click();

    setTimeout(() => {
        URL.revokeObjectURL(url);
    });
};


function ExcelExportMenuItem(props: GridExportMenuItemProps<{}>) {
    const apiRef = useGridApiContext();

    const { hideMenu } = props;
    // Todo: Passar o valor do nome do arquivo conforme viewName / profileName
    return (
        <MenuItem
            onClick={() => {
                getExcel(apiRef).then((buffer) => {
                    exportBlob(buffer, "data.xlsx");
                });
                hideMenu?.();
            }}
        >
            Excel
        </MenuItem>
    );
}

function CustomExportButton(props: ButtonProps) {
    return (
        <GridToolbarExportContainer {...props}>
            <ExcelExportMenuItem />
        </GridToolbarExportContainer>
    );
}

export const CustomToolBar: React.FC<CustomToolBarProps> = (props: CustomToolBarProps) => {
    return (
        <GridToolbarContainer {...props}>
            <CustomExportButton />
        </GridToolbarContainer>
    )
}
