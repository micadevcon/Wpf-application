namespace Магазин_техники.Classes
{
    class ClassContext
    {
        private static Магазин_техникиEntities _context;
        public static Магазин_техникиEntities GetContext()
        {
            if (_context == null)
                _context = new Магазин_техникиEntities();
            return _context;
        }
    }
}
