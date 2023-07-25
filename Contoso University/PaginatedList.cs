using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity
{
    /*لإضافة ترحيل صفحات إلى صفحة فهرس الطلاب ، ستنشئ فئة PaginatedList التي تستخدم عبارات التخطي والأخذ لتصفية البيانات على الخادم بدلاً من استرداد جميع صفوف الجدول دائمًا.ثم ستقوم بإجراء تغييرات إضافية في طريقة الفهرس وإضافة أزرار ترحيل إلى عرض الفهرس.
*/


    /*   تأخذ طريقة CreateAsync في هذا الرمز حجم الصفحة ورقم الصفحة وتطبق عبارات Skip and Take المناسبة على IQueryable.عندما يتم استدعاء ToListAsync على IQueryable ، فإنه سيعيد قائمة تحتوي فقط على الصفحة المطلوبة. يمكن استخدام الخصائص HasPreviousPage و HasNextPage لتمكين أو تعطيل أزرار الترحيل السابق والتالي.

    يتم استخدام طريقة CreateAsync بدلاً من المُنشئ لإنشاء كائن PaginatedList <T> لأن المُنشئين لا يمكنهم تشغيل تعليمات برمجية غير متزامنة.*/
    /* */
    public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        this.AddRange(items);
    }

    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex < TotalPages;

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }
}
}
